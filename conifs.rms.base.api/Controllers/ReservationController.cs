using conifs.rms.business;
using conifs.rms.data.entities;
using conifs.rms.dto.Reservation; 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;
using System.Linq;
using conifs.rms.business.validations;
//using conifs.rms.data.Migrations;
using conifs.rms.business.validations.conifs.rms.business.validations;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;


        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;

        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDto>>> GetAllReservations()
        {
            var reservations = await _reservationManager.GetAllReservationsAsync();
            var reservationDtos = reservations.Select(r => MapToReservationDto(r)).ToList();
            return Ok(reservationDtos);
        }

        [HttpGet("ByItem/{Item}")]
        public async Task<ActionResult<List<ReservationDto>>> GetReservationsByItem(Guid Item)
        {
            var reservations = await _reservationManager.GetAllReservationsAsync();
            var reservationDtos = reservations.Select(r => MapToReservationDto(r)).ToList();
            var ReservationByItem = reservationDtos.Where(dto => dto.ItemId == Item).ToList();
            return Ok(ReservationByItem);
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<GetReservation>> GetReservation(Guid id)
        {
            var reservation = await _reservationManager.getreservationasync(id);

            if (reservation == null)
            {
                return NotFound("Reservation not found.");
            }

       
            return Ok(reservation);
        }


        [HttpPost]
        public async Task<ActionResult<List<ReservationDto>>> AddReservation(GetReservation reservationDto)
        {
            var validator = new GetReservationValidator();
            var validationResult = validator.Validate(reservationDto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
                return BadRequest(errors);
            }

            var reservations = await _reservationManager.AddReservationAsync(reservationDto);
            return Ok(reservations);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ReservationDto>>> UpdateReservation(Guid id, GetReservation updatedReservationDto)
        {
            var updatedReservation = MapToGetDto(updatedReservationDto);

            var validator = new GetReservationValidator();
            var validationResult = validator.Validate(updatedReservationDto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
                return BadRequest(errors);
            }


            try
            {
                var reservations = await _reservationManager.UpdateReservationAsync(id, updatedReservationDto);
          
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ReservationDto>>> DeleteReservation(Guid id)
        {
            try
            {
                var reservations = await _reservationManager.DeleteReservationAsync(id);
              ;
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        private ReservationDto MapToReservationDto(data.entities.Reservation reservation)
        {
            return new ReservationDto
            {
                ReservationID = reservation.ReservationID,
                CustomerID = reservation.CustomerID,
                GroupId = reservation.GroupId,
                ItemId = reservation.ItemId,
                date = reservation.date,
                NoOfPeople = reservation.NoOfPeople,
                Time1 = reservation.Time1,
                Time2 = reservation.Time2
            };
        }
        private data.entities.Reservation MapToGetDto(GetReservation reservation)
        {
            return new  data.entities.Reservation
            {
                ReservationID = reservation.ReservationID,
                date = reservation.date,
                NoOfPeople = reservation.NoOfPeople,
                Time1 = reservation.Time1,
                Time2 = reservation.Time2
            };
        }
        private data.entities.Reservation MapToReservation(ReservationDto reservationDto)
        {
            return new data.entities.Reservation
            {
                ReservationID = reservationDto.ReservationID,
                CustomerID = reservationDto.CustomerID,
                GroupId = reservationDto.GroupId,
                ItemId = reservationDto.ItemId,
                date = reservationDto.date,
                NoOfPeople = reservationDto.NoOfPeople,
                Time1 = reservationDto.Time1,
                Time2 = reservationDto.Time2
            };
        }
    }
}

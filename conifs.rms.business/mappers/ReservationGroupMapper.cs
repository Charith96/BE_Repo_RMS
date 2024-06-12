using conifs.rms.data.entities;
using conifs.rms.dto.ReservationGroup;

namespace conifs.rms.business.mappers
{
    public static class ReservationGroupMapper
    {
        public static ReservationGroup Map(ReservationGroupDto input)
        {
            if (input == null)
            {
                return null;
            }

            return new ReservationGroup
            {
                GroupId = input.GroupId,
                GroupName = input.GroupName
            };
        }

        public static ReservationGroupDto Map(ReservationGroup input)
        {
            if (input == null)
            {
                return null;
            }

            return new ReservationGroupDto
            {
                GroupId = input.GroupId,
                GroupName = input.GroupName
            };
        }
    }
}

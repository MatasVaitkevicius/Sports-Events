namespace Events.Api.Controllers.Helpers
{
    public enum RouteNames
    {
        // Events

        GetAllEvents,
        GetAllEventsBySearchTerm,
        GetAllEventsBySportTypeId,
        GetEventById,
        GetEventsByUserId,

        // SportTypes

        GetAllSportTypes,
        GetSportTypeById,

        // Users

        GetAllUsers,
        GetUserByEmailAndPassword,
        GetUserByUserId
    }
}
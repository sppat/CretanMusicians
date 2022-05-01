namespace CretanMusicians.API.Responses
{
    public static class ResponeMessages
    {
        public static string NotFoundMessage(string entity)
        {
            return $"{entity} does not exist.";
        }

        public static string AlreadeyExistsMessage(string entity)
        {
            return $"{entity} already exists.";
        }

        public static string SuccessfullyAddedMessage(string entity)
        {
            return $"{entity} added successfully.";
        }

        public static string SuccessfullyDeletedMessage(string entity)
        {
            return $"{entity} deleted successfully.";
        }

        public static string SuccessfullyModifiedMessage(string entity)
        {
            return $"{entity} modified successfully.";
        }
    }
}

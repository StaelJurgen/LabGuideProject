namespace PRI.Project.Labogids.Api.DTOs.StorageConditions
{
    public class StorageConditionUpdateRequestDto
    {
        public int Id { get; set; }
        public StorageConditionAddRequestDto StorageCondition { get; set; }
    }
}

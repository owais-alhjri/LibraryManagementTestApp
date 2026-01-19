namespace LMS.Application.DTOs.BorrowRecords
{
    public class BorrowRecordResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowedDate { get; set; } 
        public DateTime? ReturnedDate { get; set; }
    }
}

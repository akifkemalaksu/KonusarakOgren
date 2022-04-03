using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.Dtos
{
    public class ExamDto : IDto
    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
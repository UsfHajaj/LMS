﻿namespace LMS.DTOs
{
    public class UpdateAnswerDto
    {
        public int? Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}

﻿namespace PavelVasilevKT_31_21.Models
{
	public class Department
	{
        public int Id { get; set; }
        public int HeadId { get; set; }
        public Teacher Head { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}

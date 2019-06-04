﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Projects_Employees//cущность проект-работник
    {
        public int Id { get; set; }


        [Required]
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }


        [Required]
        public int ProjectId { get; set; }

        public virtual Projects Project { get; set; }

        public void Copy(Projects_Employees p_e)//контструкор копирования
        {
            EmployeeId = p_e.EmployeeId;
            ProjectId = p_e.ProjectId;
        }
    }
}
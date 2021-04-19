﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Entry
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int DiaryID { get; set; }
		public string Type { get; set; }
	}
}

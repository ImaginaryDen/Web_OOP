using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.StorgeEntity
{
    public class Belonging
    {
        [Key]
        public int BelongingID { get; set; }
        public int UserID { get; set; }
        public int DiaryID { get; set; }
    }
}

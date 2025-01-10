using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Guid CreatedUserId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public Guid? UpdatedUserId { get; set; }

        public LanguageSelection Language { get; set; }
    }
}
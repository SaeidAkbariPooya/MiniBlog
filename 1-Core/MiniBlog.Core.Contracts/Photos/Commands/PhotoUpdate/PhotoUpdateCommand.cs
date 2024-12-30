using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Photos.Commands.PhotoUpdate
{
    public class PhotoUpdateCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}

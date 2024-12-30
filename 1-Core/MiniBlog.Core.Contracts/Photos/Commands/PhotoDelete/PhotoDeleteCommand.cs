using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Photos.Commands.PhotoDelete
{
    public class PhotoDeleteCommand : ICommand
    {
        public long PhotoId { get; set; }
    }
}

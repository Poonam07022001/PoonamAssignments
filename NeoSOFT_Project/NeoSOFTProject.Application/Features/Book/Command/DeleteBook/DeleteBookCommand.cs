
using MediatR;

namespace NeoSOFTProject.Application.Features.Book.Command.DeleteBook
{
  public  class DeleteBookCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}

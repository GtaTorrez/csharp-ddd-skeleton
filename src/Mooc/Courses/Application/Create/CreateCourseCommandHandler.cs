namespace CodelyTv.Mooc.Courses.Application.Create
{
    using System.Threading.Tasks;
    using CodelyTv.Shared.Domain.Bus.Command;
    using Domain;

    public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand>
    {
        private readonly CourseCreator _creator;

        public CreateCourseCommandHandler(CourseCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateCourseCommand command)
        {
            var id = new CourseId(command.Id);
            var name = new CourseName(command.Name);
            var duration = new CourseDuration(command.Duration);

            await _creator.Create(id, name, duration);
        }
    }
}
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TempExercise2.Startup))]
namespace TempExercise2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

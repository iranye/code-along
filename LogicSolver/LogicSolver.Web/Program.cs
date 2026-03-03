namespace LogicSolver.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            // app.MapGet("/", () => "Hello World!");
            //app.Run(async ctx =>
            //{
            //    await ctx.Response.WriteAsJsonAsync(new
            //    {
            //        Message = "Hello Logic Solvers!"
            //    });
            //});

            app.Run();
        }
    }
}

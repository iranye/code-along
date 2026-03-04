namespace LogicSolver.Web
{
    using LogicSolver.Web.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddTransient<Services.IEmailService, EmailService>();

            var app = builder.Build();

            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.MapRazorPages();

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

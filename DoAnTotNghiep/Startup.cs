using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.BLL;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.DAL.DataHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DoAnTotNghiep.BLL.Authorize;

namespace DoAnTotNghiep
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            



            services.AddTransient<IDataHelper, DataHelper>();
            services.AddTransient<QuanLyTuiXachContext, QuanLyTuiXachContext>();
            services.AddTransient<ILoaiTuiXachBLL, LoaiTuiXachBLL>();
            services.AddTransient<ILoaiRepository, LoaiTuiRepository>();
            services.AddTransient<ITuiXachBLL, TuiXachBLL>();
            services.AddTransient<ITuiRepositorycs, TuiRepository>();

            services.AddTransient<IKhachHangBLL, KhachHangBLL>();
            services.AddTransient<IKhachHangRepository, KhachHangRepository>();
            services.AddTransient<IDonHangBLL, DonHangBLL>();
            services.AddTransient<IDonHangRepository, DonHangRepository>();
            services.AddTransient<IChiTietDonHangBLL, ChiTietDonHangBLL>();
            services.AddTransient<IChiTietDonHangRepository, ChiTietDonHangRepository>();
            services.AddTransient<IUserBLL, UserBLL>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGiohangBLL, GioHangBLL>();
            services.AddTransient<IGioHangRepository, GioHangRepository>();

            services.AddTransient<IChiTietGioHangBLL, ChiTietGioHangBLL>();
            services.AddTransient<IChiTietGioHangRepository, ChiTietGioHangRepository>();


            services.AddTransient<IRoleBLL, RoleBLL>();
            services.AddTransient<IRoleRepository, RoleRepository>();


            //google login settingss
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");

                options.ClientId = "456907379382-8f104i1cj92d6nr4o42gjk4u0hrljv1d.apps.googleusercontent.com";
                options.ClientSecret = "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";
                // Register with User Secrets using:
                // dotnet user-secrets set "Authentication:Google:ClientSecret" "{Client Secret}"

                options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
                options.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");
                options.SaveTokens = true;
            });

            services.AddControllers();
            services.AddDirectoryBrowser();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

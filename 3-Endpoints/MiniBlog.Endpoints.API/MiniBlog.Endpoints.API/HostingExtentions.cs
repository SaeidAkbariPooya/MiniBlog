﻿using Serilog;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.ApplicationServices.Events;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using MiniPerson.Endpoints.API.CustomDecorators;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using MiniBlog.Infra.Data.Sql.Commands.Common;

namespace MiniPerson.Endpoints.API
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            string cnn = "Server =.; Database = MiniBlogDb;Integrated Security=True; MultipleActiveResultSets = true; Encrypt = false";
            builder.Services.AddZaminParrotTranslator(c =>
            {
                c.ConnectionString = cnn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "ParrotTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });
            builder.Services.AddZaminApiCore("Zamin", "MiniBlog");
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddSingleton<CommandDispatcherDecorator, CustomCommandDecorator>();
            builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>();
            builder.Services.AddSingleton<EventDispatcherDecorator, CustomEventDecorator>();


            builder.Services.AddZaminWebUserInfoService(c => { c.DefaultUserId = "1"; }, true);

            builder.Services.AddZaminAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "MiniBlog";
            });

            builder.Services.AddZaminMicrosoftSerializer();

            builder.Services.AddZaminInMemoryCaching();

            builder.Services.AddDbContext<MiniBlogCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));
            builder.Services.AddDbContext<MiniBlogQueryDbContext>(c => c.UseSqlServer(cnn));


            builder.Services.AddSwaggerGen();

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseZaminApiExceptionHandler();
            app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.Services.ReceiveEventFromRabbitMqMessageBus(new KeyValuePair<string, string>("MiniBlog", "BlogCreated"));

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
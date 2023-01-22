﻿namespace App.Presentation.Registers;

public class SwaggerUiRegister : IWebAppRegisters
{
    public void RegisterServices(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.ApiVersion.ToString());
            }
        });

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.RegisterEndpointDefinitions();
    }
}

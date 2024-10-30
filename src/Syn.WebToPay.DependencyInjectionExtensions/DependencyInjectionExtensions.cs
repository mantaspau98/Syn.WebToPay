using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Syn.WebToPay.Callback;
using Syn.WebToPay.PaymentInitiation;

namespace Syn.WebToPay.DependencyInjectionExtensions;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddWebToPay(this IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICallbackClient>(x => new CallbackClient(x.GetRequiredService<IOptions<WebToPayOptions>>().Value));
        builder.Services.AddTransient<IPaymentInitiationClient>(x => new PaymentInitiationClient(x.GetRequiredService<IOptions<WebToPayOptions>>().Value));
        builder.Services.Configure<WebToPayOptions>(builder.Configuration.GetSection(nameof(WebToPayOptions)));

        return builder;
    }
}
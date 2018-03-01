using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Recaptcha.Web.Mvc
{
	public class CaptchaValidatorAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext ctx)
		{
			ctx.ActionParameters["captchaValid"] = false;

			var validator = (ctx.Controller as Controller).GetRecaptchaVerificationHelper();

			if (string.IsNullOrEmpty(validator.Response))
			{
				return;
			}

			if (validator.VerifyRecaptchaResponse() == RecaptchaVerificationResult.Success)
			{
				ctx.ActionParameters["captchaValid"] = true;
			}
		}
	}
}

using API.Controllers.Wallet.SharedLocaleController;
using Core.Application.StatusCodes;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace API.APIResponse
{
    public class NPResponse
    {
        protected IStringLocalizer<SharedLocaleController> _baseLocalizer;
        public Dictionary<string, Object> Response;

        public NPResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> localizer)
        {
            _baseLocalizer = localizer;

            Response = new Dictionary<string, Object>();
            Response.Add(_baseLocalizer["StatusCode"], state);

            switch (state)
            {
                case SharedStatusCodes.Exists:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Failed"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer[key].Value + " " + _baseLocalizer["already_exists"].Value);
                    break;
                case SharedStatusCodes.Created:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Success"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer[key].Value + " " + _baseLocalizer["successfully created"].Value);
                    break;
                case SharedStatusCodes.Deleted:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Success"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer[key].Value + " " + _baseLocalizer["successfully deleted"].Value);
                    break;
                case SharedStatusCodes.Updated:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Success"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer[key].Value + " " + _baseLocalizer["successfully updated"].Value);
                    break;
                case SharedStatusCodes.Retrieved:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Success"].Value);
                    break;
                case SharedStatusCodes.NotFound:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Failed"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer[key].Value + " " + _baseLocalizer["was not found"].Value);
                    break;
                case SharedStatusCodes.Failed:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Failed"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer["Failed to create"].Value + " " + _baseLocalizer[key].Value);
                    break;
                case SharedStatusCodes.Unchanged:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Failed"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _baseLocalizer["No new data was sent"].Value);
                    break;
                default:
                    break;
            }
        }
    }
}

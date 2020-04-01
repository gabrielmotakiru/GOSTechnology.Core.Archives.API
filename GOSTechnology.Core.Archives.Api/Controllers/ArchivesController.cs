using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GOSTechnology.Core.Archives.Api.Infra;
using GOSTechnology.Core.Archives.Domain.BindingModels;
using GOSTechnology.Core.Archives.Domain.Configurations;
using GOSTechnology.Core.Archives.Domain.Interfaces;
using GOSTechnology.Core.Archives.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOSTechnology.Core.Archives.Api.Controllers
{
    /// <summary>
    /// ArchivesController.
    /// </summary>
    [Route(ConstantsConfiguration.API_CONTROLLER)]
    [ApiController]
    public class ArchivesController : ControllerBase
    {
        /// <summary>
        /// _archiveService.
        /// </summary>
        private readonly IArchiveService _archiveService;

        /// <summary>
        /// ArchivesController.
        /// </summary>
        /// <param name="archiveService"></param>
        public ArchivesController(IArchiveService archiveService)
        {
            this._archiveService = archiveService;
        }

        /// <summary>
        /// Post ArchiveBase64.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ArchiveBase64")]
        public async Task<IActionResult> PostArchiveBase64([FromForm]ArchiveBase64BindingModel model)
        {
            if (!(model is null))
            {
                var result = await this._archiveService.InsertArchiveBase64(model);

                if (result)
                {
                    return Ok(new ResultViewModel
                    {
                        IsSuccess = result,
                        Data = model,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_200 }
                    });
                }
                else
                {
                    return StatusCode(503, new ResultViewModel
                    {
                        IsSuccess = result,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_503 }
                    });
                }
            }
            else
            {
                return BadRequest(new ResultViewModel
                {
                    IsSuccess = false,
                    Messages = new String[] { ConstantsConfiguration.STATUS_CODE_400 }
                });
            }
        }

        /// <summary>
        /// Post ArchiveFormData.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ArchiveFormData")]
        public async Task<IActionResult> PostArchiveFormData([FromForm]ArchiveStreamBindingModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._archiveService.InsertArchiveFormData(model);

                    if (result)
                    {
                        return Ok(new ResultViewModel
                        {
                            IsSuccess = result,
                            Data = new { model.Archive.FileName, model.Archive.ContentType },
                            Messages = new String[] { ConstantsConfiguration.STATUS_CODE_200 }
                        });
                    }
                    else
                    {
                        return StatusCode(503, new ResultViewModel
                        {
                            IsSuccess = result,
                            Messages = new String[] { ConstantsConfiguration.STATUS_CODE_503 }
                        });
                    }
                }
                else
                {
                    return BadRequest(new ResultViewModel
                    {
                        IsSuccess = false,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_400 }
                    });
                }
            }
            catch (Exception exception)
            {
                return StatusCode(503, new ResultViewModel
                {
                    IsSuccess = false,
                    Messages = new String[] { exception.Message }
                });
            }
        }

        /// <summary>
        /// Get ArchiveBase64 from archiveId.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        [HttpGet("ArchiveBase64/{archiveId}")]
        public async Task<IActionResult> GetArchiveBase64([FromRoute]String archiveId)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(archiveId))
                {
                    var result = await this._archiveService.GetArchiveBase64(archiveId);

                    if (!(result is null))
                    {
                        return Ok(new ResultViewModel
                        {
                            IsSuccess = true,
                            Data = result
                        });
                    }
                    else
                    {
                        return StatusCode(503, new ResultViewModel
                        {
                            IsSuccess = false,
                            Messages = new String[] { ConstantsConfiguration.STATUS_CODE_503 }
                        });
                    }
                }
                else
                {
                    return BadRequest(new ResultViewModel
                    {
                        IsSuccess = false,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_400 }
                    });
                }
            }
            catch (Exception exception)
            {
                return StatusCode(503, new ResultViewModel
                {
                    IsSuccess = false,
                    Messages = new String[] { exception.Message }
                });
            }
        }

        /// <summary>
        /// Get ArchivePath from archiveId.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        [HttpGet("ArchivePath/{archiveId}")]
        public async Task<IActionResult> GetArchivePath([FromRoute]String archiveId)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(archiveId))
                {
                    var result = await this._archiveService.GetArchivePath(Request.Host.Value, archiveId);

                    if (!(result is null))
                    {
                        return Ok(new ResultViewModel
                        {
                            IsSuccess = true,
                            Data = result
                        });
                    }
                    else
                    {
                        return StatusCode(503, new ResultViewModel
                        {
                            IsSuccess = false,
                            Messages = new String[] { ConstantsConfiguration.STATUS_CODE_503 }
                        });
                    }
                }
                else
                {
                    return BadRequest(new ResultViewModel
                    {
                        IsSuccess = false,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_400 }
                    });
                }
            }
            catch (Exception exception)
            {
                return StatusCode(503, new ResultViewModel
                {
                    IsSuccess = false,
                    Messages = new String[] { exception.Message }
                });
            }
        }

        /// <summary>
        /// List ListArchiveBase64 from userToken.
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        [HttpGet("ArchiveBase64")]
        public async Task<IActionResult> ListArchiveBase64([FromQuery]String userToken)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(userToken))
                {
                    var result = await this._archiveService.ListArchiveBase64(userToken);

                    if (!(result is null))
                    {
                        return Ok(new ResultViewModel
                        {
                            IsSuccess = true,
                            Data = result
                        });
                    }
                    else
                    {
                        return StatusCode(503, new ResultViewModel
                        {
                            IsSuccess = false,
                            Messages = new String[] { ConstantsConfiguration.STATUS_CODE_503 }
                        });
                    }
                }
                else
                {
                    return BadRequest(new ResultViewModel
                    {
                        IsSuccess = false,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_400 }
                    });
                }
            }
            catch (Exception exception)
            {
                return StatusCode(503, new ResultViewModel
                {
                    IsSuccess = false,
                    Messages = new String[] { exception.Message }
                });
            }
        }

        /// <summary>
        /// List ArchivePath from userToken.
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        [HttpGet("ArchivePath")]
        public async Task<IActionResult> ListArchivePath([FromQuery]String userToken)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(userToken))
                {
                    var result = await this._archiveService.ListArchivePath(Request.Host.Value, userToken);

                    if (!(result is null))
                    {
                        return Ok(new ResultViewModel
                        {
                            IsSuccess = true,
                            Data = result
                        });
                    }
                    else
                    {
                        return StatusCode(503, new ResultViewModel
                        {
                            IsSuccess = false,
                            Messages = new String[] { ConstantsConfiguration.STATUS_CODE_503 }
                        });
                    }
                }
                else
                {
                    return BadRequest(new ResultViewModel
                    {
                        IsSuccess = false,
                        Messages = new String[] { ConstantsConfiguration.STATUS_CODE_400 }
                    });
                }
            }
            catch (Exception exception)
            {
                return StatusCode(503, new ResultViewModel
                {
                    IsSuccess = false,
                    Messages = new String[] { exception.Message }
                });
            }
        }
    }
}
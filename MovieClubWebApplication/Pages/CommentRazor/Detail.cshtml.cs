using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Commentts;
using App.Core.ApplicationService.Dtos.CommentDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CommentRazor
{
    public class DetailModel : PageModel
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public DetailModel(ICommentService _commentService, IMapper _mapper)
        {
            commentService = _commentService;
            mapper = _mapper;
        }

        public CommentsOutputDto commentOutputDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempCommentOutput = await commentService.Get(id.Value);
            commentOutputDto = mapper.Map<CommentsOutputDto>(tempCommentOutput);

            if (commentOutputDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

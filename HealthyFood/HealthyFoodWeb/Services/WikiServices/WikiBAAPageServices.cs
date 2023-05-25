﻿using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;
using Data.Sql.Repositories;
using Data.Interface.Models;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class WikiBAAPageServices : IWikiBAAPageServices
    {
        private IWikiBaaRepository _wikiBaaRepository;

        private IWikiBaaCommentRepository _wikiBaaCommentRepository;

        private IAuthService _authService;

        public WikiBAAPageServices(IWikiBaaRepository wikiBaaRepository, IAuthService authService, IWikiBaaCommentRepository wikiBaaCommentRepository)
        {
            _wikiBaaRepository = wikiBaaRepository;
            _authService = authService;
            _wikiBaaCommentRepository = wikiBaaCommentRepository;
        }

        public void CreateBlock(BLockPageBaaViewModel block)
        {
            var user = _authService.GetUser();
            var dbBlockBAA = new PageWikiBlock()
            {
                Id = block.Id,
                Title = block.Title ?? new string("<blank>"),
                Text = block.Text ?? new string(""),
                Author = user,
                UrlImg = block.Img?
                .Select(x => new WikiBlockImg
                {
                    Id = x.Id,
                    Url = x.Url ?? new string(""),
                })
                .ToList() ?? new List<WikiBlockImg>()
            };
            _wikiBaaRepository.Add(dbBlockBAA);
        }

        public int CreateComment(int blockId, string comment)
        {
            var blockDb = _wikiBaaRepository.Get(blockId);
            var user = _authService.GetUser();
            return _wikiBaaCommentRepository.CreateComment(user, blockDb, comment);
        }

        public IEnumerable<BLockPageBaaViewModel> GetBlocksWithAuthorAndComments()
        {

            return _wikiBaaRepository.GetBlocksWithAuthorComMents()
                .Select(
                x => new BLockPageBaaViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    Author = x.Author,
                    Img = x.Img?
                    .Select(Img => new WikiBlockImgViewModel
                    {
                        Id = Img.Id,
                        Url = Img.Url,
                    })
                    .ToList() ?? new List<WikiBlockImgViewModel>(),
                    CommentAndAuthor = x.CommentAndAuthor?
                    .Select
                    (c => new CommentAndAuthorViewModel
                    {
                        Comment = c.Comment,
                        Author = c.Author.Name,
                        CommentId = c.CommentId,
                        AuthorId = c.Author.Id
                    })
                    .ToList() ?? new List<CommentAndAuthorViewModel>()
                });
        }

        public void RemoveBlock(int blockId)
        {
            _wikiBaaRepository.Remove(blockId);
        }

        public void RemoveComment(int commentId)
        {
            _wikiBaaCommentRepository.RemoveComment(commentId);
        }

        public BLockPageBaaViewModel GetBLockPageBaaViewModel(int id)
        {
            var blockPage = _wikiBaaRepository.GetBLockPageBaa(id);
            return new BLockPageBaaViewModel
            {
                Id = blockPage.Id,
                Title = blockPage.Title,
                Text = blockPage.Text,
            };
        }

        public void Updateblock(int id, string title, string text)
        {
            _wikiBaaRepository.UpdateBlock(id, title, text);
        }

        public BLockPageBaaViewModel GetBlockCommentPageBaaViewModel(int commentId)
        {
            var blockCommentPage = _wikiBaaCommentRepository.GetBlockCommentPageBaaViewModel(commentId);
            return new BLockPageBaaViewModel
            {
                Id = blockCommentPage.CommentId,
                Text = blockCommentPage.Comment,
            };
        }

        public void UpdateBlockComment(int Id, string Text)
        {
            _wikiBaaCommentRepository.UpdateBlockComment(Id, Text);
        }
    }
}

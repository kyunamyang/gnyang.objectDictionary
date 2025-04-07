using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using AutoMapper;
using gnyang.objectDictionary.Common;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.ViewModel;
using gnyang.objectDictionary.Service.Interface;
using gnyang.objectDictionary.Repository.Interface;
using System.Transactions;

namespace gnyang.objectDictionary.Service
{
    public class SourceService : ServiceBase, IGenericService<SourceViewModel>
    {
        private readonly IMapper mapper;
        private readonly IGenericCommandRepository<Source> sourceCommandRepository;
        private readonly IGenericQueryRepository<Source> sourceQueryRepository;
        private readonly IGenericQueryRepository<User> userQueryRepository;
        private readonly IGenericQueryRepository<Model> modelQueryRepository;

        public SourceService(IMapper mapper,
            IGenericCommandRepository<Source> sourceCommandRepository,
            IGenericQueryRepository<Source> sourceQueryRepository,
            IGenericQueryRepository<User> userQueryRepository,
            IGenericQueryRepository<Model> modelQueryRepository)
        {
            this.mapper = mapper;
            this.sourceQueryRepository = sourceQueryRepository;
            this.sourceCommandRepository = sourceCommandRepository;
            this.userQueryRepository = userQueryRepository;
            this.modelQueryRepository = modelQueryRepository;
        }

        // 자식 개체까지 조회하여 리턴
        public SourceViewModel GetById(Guid id)
        {
            var source = sourceQueryRepository.GetById(id);
            var user = userQueryRepository.GetById(new Guid(source.UserId));

            var sourceViewModel = mapper.Map<SourceViewModel>(source);
            var userViewModel = mapper.Map<UserViewModel>(user);
            var modelViewModel = mapper.Map<ModelViewModel>(new Guid(source.ModelId));

            sourceViewModel.User = userViewModel;
            sourceViewModel.Model = modelViewModel;

            return sourceViewModel;
        }

        public IEnumerable<SourceViewModel> GetAll(IDictionary<string, string> conditions)
        {
            var sources = sourceQueryRepository.GetAll(conditions);
            return mapper.Map<IEnumerable<SourceViewModel>>(sources);
        }

        public void Create(SourceViewModel sourceViewModel)
        {
            var source = mapper.Map<Source>(sourceViewModel);
            sourceCommandRepository.Create(source);
        }

        public void Update(SourceViewModel sourceViewModel)
        {
            var source = mapper.Map<Source>(sourceViewModel);
            sourceCommandRepository.Update(source);
        }

        public void Delete(Guid id)
        {
            sourceCommandRepository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using AutoMapper;
using Company.ObjectDictionary.Common;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.ViewModel;
using Company.ObjectDictionary.Service.Interface;
using Company.ObjectDictionary.Repository.Interface;
using System.Transactions;

namespace Company.ObjectDictionary.Service
{
    public class FieldService : ServiceBase, IGenericService<FieldViewModel>
    {
        private readonly IMapper mapper;
        private readonly IGenericCommandRepository<Field> fieldCommandRepository;
        private readonly IGenericQueryRepository<Field> fieldQueryRepository;
        private readonly IGenericQueryRepository<User> userQueryRepository;
        private readonly IGenericQueryRepository<Model> modelQueryRepository;

        public FieldService(IMapper mapper,
            IGenericCommandRepository<Field> fieldCommandRepository,
            IGenericQueryRepository<Field> fieldQueryRepository,
            IGenericQueryRepository<User> userQueryRepository,
            IGenericQueryRepository<Model> modelQueryRepository)
        {
            this.mapper = mapper;
            this.fieldQueryRepository = fieldQueryRepository;
            this.fieldCommandRepository = fieldCommandRepository;
            this.userQueryRepository = userQueryRepository;
            this.modelQueryRepository = modelQueryRepository;
        }

        // 자식 개체까지 조회하여 리턴
        public FieldViewModel GetById(Guid id)
        {
            var field = fieldQueryRepository.GetById(id);
            var user = userQueryRepository.GetById(new Guid(field.UserId));
            var model = modelQueryRepository.GetById(new Guid(field.ModelId));

            var fieldViewModel = mapper.Map<FieldViewModel>(field);
            var userViewModel = mapper.Map<UserViewModel>(user);
            var modelViewModel = mapper.Map<ModelViewModel>(model);

            fieldViewModel.User = userViewModel;
            fieldViewModel.Model = modelViewModel;

            return fieldViewModel;
        }

        public IEnumerable<FieldViewModel> GetAll(IDictionary<string, string> conditions)
        {
            var fields = fieldQueryRepository.GetAll(conditions);
            return mapper.Map<IEnumerable<FieldViewModel>>(fields);
        }

        public void Create(FieldViewModel fieldViewModel)
        {
            var field = mapper.Map<Field>(fieldViewModel);
            fieldCommandRepository.Create(field);
        }

        public void Update(FieldViewModel fieldViewModel)
        {
            var field = mapper.Map<Field>(fieldViewModel);
            fieldCommandRepository.Update(field);
        }

        public void Delete(Guid id)
        {
            fieldCommandRepository.Delete(id);
        }
    }
}

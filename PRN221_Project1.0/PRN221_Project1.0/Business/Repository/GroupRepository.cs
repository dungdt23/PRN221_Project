﻿using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class GroupRepository : IGroupRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        GroupManager manager;
        public GroupRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GroupDTO GetGroup(int sessionId)
        {
            manager = new GroupManager(_context);
            Group group = manager.GetGroup(sessionId);
            GroupDTO groupDTO = _mapper.Map<GroupDTO>(group);
            return groupDTO;
        }
        public List<GroupDTO> GetGroups(string lectureId)
        {
            manager = new GroupManager(_context);
            List<Group> groups = manager.GetGroups(lectureId);
            List<GroupDTO> groupDTOs = _mapper.Map<List<GroupDTO>>(groups);
            return groupDTOs;
        }
    }
}

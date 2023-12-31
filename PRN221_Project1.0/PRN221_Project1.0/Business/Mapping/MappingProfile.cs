﻿using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Lecture, LectureDTO>();
            CreateMap<LectureDTO, Lecture>();
            CreateMap<Session, SessionDTO>();
            CreateMap<SessionDTO, Session>();
            CreateMap<Slot, SlotDTO>();
            CreateMap<SlotDTO, Slot>();
            CreateMap<Group, GroupDTO>();
            CreateMap<GroupDTO, Group>();
            CreateMap<Enroll, EnrollDTO>();
            CreateMap<EnrollDTO, Enroll>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            CreateMap<CampusDTO, Campus>();
            CreateMap<Campus, CampusDTO>();
            CreateMap<TermDTO, Term>();
            CreateMap<Term, TermDTO>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();
            CreateMap<RoomDTO, Room>();
            CreateMap<Room, RoomDTO>();
            CreateMap<Attendance, AttendanceDTO>()
                .ForMember(dest => dest.Student, act => act.MapFrom(src => src.Student));
            CreateMap<AttendanceDTO, Attendance>()
                .ForMember(dest => dest.Student, act => act.MapFrom(src => src.Student))
    ;

        }
    }
}

using Application.Dtos.RequestModel.Book;
using Application.Dtos.RequestModel.Category;
using Application.Dtos.RequestModel.UserRequest;
using Application.Dtos.ResponseModel.Book;
using Application.Dtos.ResponseModel.BorrowingRequest;
using Application.Dtos.ResponseModel.UserRequest;
using AutoMapper;
using Domain;

namespace API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateBookRequest, Book>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<Book, AdminBookDetailResponse>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));
            CreateMap<UserRequest, CreateUserRequestRequest>().ReverseMap();
            CreateMap<UserRequest, GetUserRequestResponse>()
                .ForMember(dest => dest.BookImage, opt => opt.MapFrom(src => src.Book.Image))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Book.Category.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Book.Author))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Book.Id))
                .ForMember(dest => dest.RequesterName, opt => opt.MapFrom(src => src.Requester.UserName));
            CreateMap<BorrowingRequest, UserBorrowingHistoryResponse>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.BorrowingRequestDetails));
            CreateMap<BorrowingRequestDetail, UserBorrowingHistoryDetail>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Book.Image))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Book.Author));
            CreateMap<BorrowingRequest, BorrowingRequestResponse>()
                .ForMember(dest => dest.Requester, opt => opt.MapFrom(src => src.Requester.UserName));
            CreateMap<BorrowingRequest, BorrowingRequestDetailResponse>()
                .ForMember(dest => dest.Approver, opt => opt.MapFrom(src => src.Approver.UserName))
                .ForMember(dest => dest.Requester, opt => opt.MapFrom(src => src.Requester.UserName))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BorrowingRequestDetails));
            CreateMap<BorrowingRequestDetail, RequestDetails>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Book.Image))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Book.Id));

        }
    }
}

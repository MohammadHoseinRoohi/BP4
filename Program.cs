using Microsoft.AspNetCore.Mvc;
using Practice02.DbContextes;
using Practice02.DTOs.Books;
using Practice02.DTOs.Common;
using Practice02.DTOs.Members;
using Practice02.Entities;
using Practice02.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<LibraryDB>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/books/list", ([FromServices] LibraryDB db) =>
{
    return db.Books.Select(b => new BookListDto
    {
        Writer = b.Writer,
        Title = b.Title,
        Price = b.Price,
        Id = b.Guid,
        Publisher = b.Publisher
    }).ToList();
});
app.MapPost("api/v1/books/create", (
    [FromServices] LibraryDB db,
    [FromBody] BookAddDto bookAddDto) =>
{
    var book = new Book
    {
        Writer = bookAddDto.Writer,
        Title = bookAddDto.Title,
        Price = bookAddDto.Price,
        Publisher = !string.IsNullOrEmpty(bookAddDto.Publisher) ? bookAddDto.Publisher : "بی عنوان"
    };
    db.Books.Add(book);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = true,
        Message = "Book Created!"
    };
});
app.MapPut("api/v1/books/update/{guid}", (
    [FromRoute] string guid,
    [FromServices] LibraryDB db,
    [FromBody] BookUpdateDto bookUpdateDto) =>
{
    var LastBook = db.Books.FirstOrDefault(m => m.Guid == guid);
    if (LastBook == null)
    {
        return new CommandResultDto
        {
            Successfull = false,
            Message = "Not Found!"
        };
    }
    LastBook.Writer = bookUpdateDto.Writer;
    LastBook.Title = !string.IsNullOrEmpty(bookUpdateDto.Title) ? bookUpdateDto.Title : LastBook.Title;
    LastBook.Publisher = !string.IsNullOrEmpty(bookUpdateDto.Publisher) ? bookUpdateDto.Publisher : LastBook.Publisher;
    // newBook.Price = !int.IsNullOrEmpty(bookUpdateDto.Price)? bookUpdateDto : 213;
    LastBook.Price = bookUpdateDto.Price ?? LastBook.Price;
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = true,
        Message = "Book Updated!"
    };
});
app.MapDelete("api/v1/books/remove/{guid}", (
    [FromRoute] string guid,
    [FromServices] LibraryDB db) =>
{
    var book = db.Books.FirstOrDefault(m => m.Guid == guid);
    if (book == null)
    {
        return new CommandResultDto
        {
            Successfull = false,
            Message = "Not Found!!"
        };
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = false,
        Message = "Book Removed!"
    };
});
app.MapGet("api/v1/members/list", ([FromServices] LibraryDB db) =>
{
    return db.Members.Select(m => new MemberListDto
    {
        Firstname = m.Firstname,
        Lastname = m.Lastname,
        Id = m.Guid,
        FotherName = m.FotherName,
        Gender = m.Gender
    }).ToList();
});
app.MapPost("api/v1/members/create", (
    [FromServices] LibraryDB db,
    [FromBody] MemberAddDto memberAddDto) =>
{
    var member = new Member
    {
        Firstname = memberAddDto.Firstname,
        Lastname = memberAddDto.Lastname,
        FotherName = !string.IsNullOrEmpty(memberAddDto.FotherName)?memberAddDto.FotherName:"بی عنوان",
        Gender = memberAddDto.Gender
    };
    db.Members.Add(member);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = false,
        Message = "Member Created!"        
    };
});
app.MapPut("api/v1/members/update/{guid}", (
    [FromRoute]string guid, 
    [FromServices]LibraryDB db, 
    [FromBody]MemberUpdateDto memberUpdateDto) =>
{
    var lastMember = db.Members.FirstOrDefault(lm => lm.Guid ==guid);
    if (lastMember == null)
    {
        return new CommandResultDto
        {
            Successfull = false,
            Message = "Not Found!!"            
        };
    }
    lastMember.Firstname = !string.IsNullOrEmpty(memberUpdateDto.Firstname)? memberUpdateDto.Firstname : lastMember.Firstname;
    lastMember.Lastname = memberUpdateDto.Lastname;
    lastMember.FotherName = !string.IsNullOrEmpty(memberUpdateDto.FotherName)?memberUpdateDto.FotherName:lastMember.FotherName;
    lastMember.Gender = memberUpdateDto.Gender ?? lastMember.Gender;
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = false,
        Message = "Member Updated!"
    };
});
app.MapDelete("api/v1/members/remove/{guid}", (
    [FromRoute]string guid, 
    [FromServices]LibraryDB db) =>
{
    var member = db.Members.FirstOrDefault(m=>m.Guid == guid);
    if (member == null)
    {
        return new CommandResultDto
        {
            Successfull = false,
            Message = "Not Found!!"            
        };
    }
    db.Members.Remove(member);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = true,
        Message = "Member Removed!"        
    };
});

app.Run();
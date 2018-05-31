using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BooksApiDbLib;
using BooksApiDbLib.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Services
{
    public class BookService
    {
        private BookContext _Entities = new BookContext();
        public BookService()
        {
        }
        #region Authors

        public List<Author> GetAuthors()
        {
            return this._Entities.Authors.ToList();
        }

        public Author GetAuthorById(long id)
        {
            return this._Entities.Authors.First(author => author.Identifier == id);
        }

        public Author AddAuthor(Author author)
        {
            this._Entities.Authors.Add(author);
            this._Entities.SaveChanges();
            return author;
        }

        #endregion

        #region Books

        public List<Book> GetBooks()
        {
            return this._Entities.Books.Include(book => book.Author).ToList();
        }
        public Book GetBookById(long id)
        {
            return this._Entities.Books.Include(book => book.Author).First(book => book.Identifier == id);
        }

        public Book AddBook(long id, Book book)
        {
            return this.CreateNewElement<Book, Author>(book, id);
        }

        #endregion

        #region Comments

        public List<BookComment> GetBookComments(long idBook)
        {
            return this._Entities.BookComments.Where(comment => comment.Book.Identifier == idBook).ToList();
        }

        public BookComment AddBookComment(long idBook, BookComment comment)
        {
            return this.CreateNewElement<BookComment,Book>(comment, idBook);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Sauvegarde un nouvel élément qui possède un parent
        /// </summary>
        /// <param name="entity">Entité à sauvegarder</param>
        /// <param name="id">Identifiant du parent</param>
        /// <typeparam name="T">Type de l'entité à sauvegarder</typeparam>
        /// <typeparam name="U">Type de l'entité parente</typeparam>
        /// <returns></returns>
        private T CreateNewElement<T, U>(T entity, long id)
            where U : class, IHaveIdentifier
            where T : class
        {
            U parent = this._Entities.Set<U>().FirstOrDefault(u => u.Identifier == id);
            if (parent == null)
            {
                throw new InvalidOperationException("L'entité n'existe pas");
            }
            else
            {
                typeof(T).GetProperties()
                    .Where(property => property.GetType().Name == typeof(U).Name)
                    .First().SetValue(entity, parent);
                this._Entities.Set<T>().Add(entity);
                this._Entities.SaveChanges();
                return entity;
            }
        }

        #endregion

    }
}
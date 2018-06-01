import gql from 'graphql-tag';

export const addBook = gql`
mutation AddBook($book: InputBook!, $identifier: Long!) {
  newBook(book: $book, id: $identifier) {
    entity {
      id
    }
  }
}
`;

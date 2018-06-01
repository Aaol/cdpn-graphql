import gql from 'graphql-tag';


export const getAuthors = gql`
  query GetAuthors {
    authors {
      entity {
        firstname
        id
        lastname
        birthdate {
          date
        }
      }
      errors
    }
  }
`;

export const getAuthor = gql`
query GetAuthor($identifier: Long!) {
    author(id: $identifier) {
      entity {
        firstname
        lastname
        birthdate {
          date
        }
        books {
          title
          publishdate {
            date
          }
          type
          price
        }
      }
      errors
    }
  }
`;

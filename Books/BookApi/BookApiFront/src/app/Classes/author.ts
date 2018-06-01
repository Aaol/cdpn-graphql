import { DateTime } from './datetime';
import { Book } from './book';
import { HaveIdentifier } from './haveidentifier';

export class Author extends HaveIdentifier {
  firstname: string;
  lastname: string;
  birthdate: DateTime;
  books: Book[];
}

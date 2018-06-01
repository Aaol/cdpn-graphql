import { DateTime } from './datetime';
import { Author } from './author';
import { HaveIdentifier } from './haveidentifier';

export class Book extends HaveIdentifier  {
  title: string;
  type: string;
  author: Author;
  publishdate: DateTime;
  price: number;
}

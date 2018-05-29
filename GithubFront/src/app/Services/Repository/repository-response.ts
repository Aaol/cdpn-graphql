import { Repository } from './repository';

export class RepositoryReponse {
  user: User;
}
export class User {
  repositories: RepositoryNode;
}
export class RepositoryNode {
  nodes: Repository[];
}

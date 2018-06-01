export class EntityResponse<T> {
  entity: T;
  success: string;
  errors: string[];
  warnings: string[];
}

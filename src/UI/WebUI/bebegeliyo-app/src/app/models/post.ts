import {Tag} from "./tag";

export class Post {
  id!: number;
  title!: string;
  tags!: Tag[];
  content!: string;
  postType!: number;
  description!: string;
}

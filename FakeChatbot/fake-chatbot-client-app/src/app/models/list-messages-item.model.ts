export default interface ListMessagesItemResponse {
  id: number;
  text: string;
  author: number;
  mark: number | null;
  timestamp: Date;
}

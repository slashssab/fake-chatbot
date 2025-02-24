export default interface Message {
  id: number;
  text: string;
  author: 'user' | 'chat';
  mark: number | null;
  timestamp: Date;
}

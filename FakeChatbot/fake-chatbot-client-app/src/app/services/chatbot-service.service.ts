import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import Message from '../models/message.model';
import ListMessagesItemResponse from '../models/list-messages-item.model';

@Injectable({
  providedIn: 'root',
})
export class ChatbotServiceService {
  public chatResponses = new Subject<Message[]>();
  private apiBaseUrl: string;
  constructor() {
    // Advantage of hosting FE and BE in the same domain.
    // We should have created Environment files with crucial variables to be defined
    // this.apiBaseUrl =
    //   window.location.protocol + '/api';

    this.apiBaseUrl = 'https://localhost:44354/api';
  }

  public async processMessage(message: string) {
    const request = {
      method: 'POST',
      body: JSON.stringify({ userInput: message }),
      headers: {
        'Content-Type': 'application/json',
      },
    };

    const chatResponse = await fetch(`${this.apiBaseUrl}/messages`, request);
    const result = await chatResponse.json();
    const chatMessages = result.map((m: ListMessagesItemResponse) => {
      return {
        id: m.id,
        text: m.text,
        mark: m.mark,
        author: m.author === 0 ? 'user' : 'chat',
        timestamp: m.timestamp
      } as Message
    })

    this.chatResponses.next(chatMessages);
  }

  public async listMessages() {
    const request = {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    };

    const chatResponse = await fetch(`${this.apiBaseUrl}/messages`, request);
    const result = await chatResponse.json();
    const chatMessages = result.map((m: ListMessagesItemResponse) => {
      return {
        id: m.id,
        text: m.text,
        mark: m.mark,
        author: m.author === 0 ? 'user' : 'chat',
        timestamp: m.timestamp
      } as Message
    })

    this.chatResponses.next(chatMessages);
  }

  public async updateMessageMark(id: number, mark: number) {
    const request = {
      method: 'PATCH',
      body: JSON.stringify({ mark: mark }),
      headers: {
        'Content-Type': 'application/json',
      },
    };

    const chatResponse = await fetch(`${this.apiBaseUrl}/messages${id}`, request);
    const result = await chatResponse.json();
    const chatMessages = result.map((m: ListMessagesItemResponse) => {
      return {
        id: m.id,
        text: m.text,
        mark: m.mark,
        author: m.author === 0 ? 'user' : 'chat',
        timestamp: m.timestamp
      } as Message
    })

    this.chatResponses.next(chatMessages);
  }
}

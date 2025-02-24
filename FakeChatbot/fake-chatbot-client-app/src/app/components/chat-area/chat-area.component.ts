import { DatePipe, NgClass } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ChatbotServiceService } from '../../services/chatbot-service.service';
import Message from '../../models/message.model';

@Component({
  selector: 'app-chat-area',
  standalone: true,
  imports: [
    NgClass,
    DatePipe,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './chat-area.component.html',
  styleUrl: './chat-area.component.scss',
})
export class ChatAreaComponent {
  userInputFormGroup: FormGroup = this.BuildUserInputFormGroup();
  messageCollection: Message[] = [];

  constructor(private chatBotService: ChatbotServiceService) {
    this.chatBotService.listMessages();
    this.chatBotService.chatResponses
      .pipe(takeUntilDestroyed())
      .subscribe((val) => {
        this.messageCollection = val;
      });
  }

  private BuildUserInputFormGroup(): FormGroup {
    const controls = {
      userInputControl: new FormControl('', Validators.required),
    };
    return new FormGroup(controls);
  }

  public async sendMessage() {
    const userInputMessage =
      this.userInputFormGroup.get('userInputControl')?.value;
    await this.chatBotService.processMessage(userInputMessage);

    this.userInputFormGroup.controls['userInputControl'].setValue('');
  }

  public async updateMessageMark() {
    const userInputMessage =
      this.userInputFormGroup.get('userInputControl')?.value;
    await this.chatBotService.processMessage(userInputMessage);

    this.userInputFormGroup.controls['userInputControl'].setValue('');
  }
}

import { User } from './User'
export interface APIChatMessage {
    id: number;
    content: string;
    timePosted: number;
    uploadedBy: User;
    wasEdited: boolean;
    wasRemoved: boolean;
}
export interface ChatMessage {
    id: number;
    content: string;
    timePosted: number;
    uploaderName: string;
    uploaderId: number;
    wasEdited: boolean;
    wasRemoved: boolean;
}
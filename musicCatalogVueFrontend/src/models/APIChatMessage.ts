export interface APIChatMessage {
    id: number;
    content: string;
    timePosted: number;
    uploadedBy: {
        userName: string;
        userId: number;
    }
    wasEdited: boolean;
    wasRemoved: boolean;
}
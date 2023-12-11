export interface User {
    userId: number;
    userName: string;
    originalUserName: string;
    createdAt: string;
    userRole: string;
    mutedUntil: number | null;
    bannedUntil: number | null;
}

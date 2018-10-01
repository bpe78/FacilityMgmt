export interface Facility {
    id: string;
    name: string;
    short_name: string;
    groupId: number;
    accessToken: string;
    geography: string;
    country: string;
    areaCode: string;
    tvProviderId: string;
    tvProviderName: string;
    tvProviderType: string;
    isActive: boolean;
    refreshTimestamp: number;
    created: Date;
    modified: Date;
}
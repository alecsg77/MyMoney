import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'MyMoney',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44323/',
    redirectUri: baseUrl,
    clientId: 'MyMoney_App',
    responseType: 'code',
    scope: 'offline_access MyMoney',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44351',
      rootNamespace: 'AlecsG77.MyMoney',
    },
  },
} as Environment;

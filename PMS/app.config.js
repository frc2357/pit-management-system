export default ({ config }) => ({
  expo: {
    name: 'PMS',
    slug: 'PMS',
    version: '1.0.0',
    orientation: 'portrait',
    icon: './assets/icon.png',
    userInterfaceStyle: 'light',
    splash: {
      image: './assets/splash.png',
      resizeMode: 'contain',
      backgroundColor: '#ffffff',
    },
    assetBundlePatterns: ['**/*'],
    ios: {
      supportsTablet: true,
    },
    android: {
      adaptiveIcon: {
        foregroundImage: './assets/adaptive-icon.png',
        backgroundColor: '#ffffff',
      },
      package: 'com.nolanc1223.PMS',
    },
    web: {
      favicon: './assets/favicon.png',
    },
    extra: {
      eas: {
        projectId: 'fcb7793b-c50b-4a8f-831a-ccd8916dd4b8',
      },
      storybookEnabled: process.env.STORYBOOK_ENABLED,
    },
  },
});

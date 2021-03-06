module.exports = {
  purge: [
    "IssueManager.Client.Blazor.WASM/**/*.html",
    "IssueManager.Client.Blazor.WASM/**/*.razor",
    "IssueManager.Client.Blazor.WASM/**/*.cs",
    "IssueManager.Client.Blazor.Server/**/*.html",
    "IssueManager.Client.Blazor.Server/**/*.razor",
    "IssueManager.Client.Blazor.Server/**/*.cs",
  ],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [],
}

import { createApp, provide, inject } from 'vue'

const app = createApp({})
const emitter = app.config.globalProperties.$emitter = app.config.globalProperties.$emitter || {}

export function emitShowInform(show, isFailed, message) {
  emitter.$emit('showInform', show, isFailed, message)
}

export const provideEmitter = () => {
  provide('$emitter', emitter)
}

export const useEmitter = () => {
  const emitter = inject('$emitter')
  if (!emitter) {
    throw new Error('useEmitter() must be used inside a setup() function')
  }
  return emitter
}